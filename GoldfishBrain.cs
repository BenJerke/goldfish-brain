using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoldfishBrainLibrary;

namespace GoldfishBrain
{
    public partial class GoldfishBrain : Form
    {
        //new session
        private Session session = new Session();
        //load data from last session into this one
        public GoldfishBrain()
        {
            InitializeComponent();
            StartSessionTimer(session);
            WriteLabels(session);
        }
        private void GoldfishBrain_Load(object sender, EventArgs e)
        {
            //pull task and project lists + associated data from save file
        }
        private void GoldfishBrain_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopActiveTaskTimer(session);
            StopSessionTimer(session);
            session.EndDatetime = DateTime.Now;
            Report(session);
            return;
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            SubmitNewTask(session);
            StartActiveTaskTimer(session);
            WriteLabels(session);
            return;
        }
        private void completeTaskButton_Click(object sender, EventArgs e)
        {
            StopActiveTaskTimer(session);
            CompleteActiveTask(session);
            SwitchActiveTask(session);
            StartActiveTaskTimer(session);
            WriteLabels(session);
            return;
        }
        private void switchTaskButton_Click(object sender, EventArgs e)
        {
            SwitchActiveTask(session);
            //RunActiveTaskTimer(session);
            WriteLabels(session);
            return;
        }
        private void cancelTaskButton_Click(object sender, EventArgs e)
        {
            StopActiveTaskTimer(session);
            CancelActiveTask(session);
            SwitchActiveTask(session);
            StartActiveTaskTimer(session);
            WriteLabels(session);
            return;
        }
        private void SubmitNewTask(Session CurrentSession)
        {
            if (taskEntryTextBox.Text.Length > 0 && projectEntryTextBox.Text.Length > 0)
            {
                //create new task and project, put task on project
                Project NewPrj = new Project(projectEntryTextBox.Text);
                WorkTask NewTask = new WorkTask(taskEntryTextBox.Text, NewPrj);

                CurrentSession.IncompleteTasks.Add(NewTask);

                taskEntryTextBox.Clear();

                if (GetActiveTask() == null)
                {
                    CurrentSession.ActiveTask = CurrentSession.IncompleteTasks[0];
                    CurrentSession.IncompleteTasks.RemoveAt(0);
                }
                session = CurrentSession;
                return;
            }
            else if (taskEntryTextBox.Text.Length > 0)
            {
                WorkTask NewTask = new WorkTask(taskEntryTextBox.Text, null);
                //Create new task
                session.IncompleteTasks.Add(NewTask);

                if (GetActiveTask() == null)
                {
                    CurrentSession.ActiveTask = CurrentSession.IncompleteTasks[0];
                    session.IncompleteTasks.RemoveAt(0);
                }
                taskEntryTextBox.Clear();
                session = CurrentSession;
                return;


            }
            else
            {
                //If nothing's entered, get mad
                MessageBox.Show("Enter a task.");
                return;
            }
        }
        private void SubmitAndSwitch(Session CurrentSession)
        {
            SubmitNewTask(CurrentSession);
            if (CurrentSession.IncompleteTasks.Count >= 1)
            {
                WorkTask Switcher = CurrentSession.IncompleteTasks.Last();
                CurrentSession.IncompleteTasks.Insert(0, Switcher);
                CurrentSession.IncompleteTasks.RemoveAt(CurrentSession.IncompleteTasks.Count - 1);
                CurrentSession.IncompleteTasks.Add(CurrentSession.ActiveTask);
                CurrentSession.ActiveTask = CurrentSession.IncompleteTasks[0];
                CurrentSession.IncompleteTasks.RemoveAt(0);
                session = CurrentSession;
                return;
            }
            else //should just work if we're submitting the first item.
            return;
        }
        private WorkTask GetActiveTask()
        {
            if (session.ActiveTask != null)
            {
                return session.ActiveTask;
            }
            else return null;
        }
        private void StartActiveTaskTimer(Session CurrentSession)
        {
            if (GetActiveTask() != null)
            {
                WorkTask task = GetActiveTask();
                DateTime StartInstant = DateTime.Now;
                if (task.ElapsedTime == TimeSpan.Zero)
                {
                    task.StartDatetime = StartInstant;
                    return;
                }
            }
            else return;
        }
        private void StopActiveTaskTimer(Session CurrentSession)
        {
            if (GetActiveTask() != null)
            {
                WorkTask task = GetActiveTask();
                task.ElapsedTime = task.ElapsedTime + (DateTime.Now - task.StartDatetime);
                return;
            }
            else return;
        }
        private void StartSessionTimer(Session CurrentSession)
        {
            DateTime StartInstant = DateTime.Now;
            if (CurrentSession.ElapsedTime == TimeSpan.Zero)
            {
                CurrentSession.StartDatetime = DateTime.Now;
                return;
            }
            else return;
        }
        private void StopSessionTimer(Session CurrentSession)
        {
            CurrentSession.ElapsedTime = CurrentSession.ElapsedTime + (DateTime.Now - CurrentSession.StartDatetime);
        }
        private Session SwitchActiveTask(Session CurrentSession)
        {
            if (CurrentSession.ActiveTask != null && CurrentSession.IncompleteTasks.Count() > 0)
            {
                CurrentSession.IsActive = false;
                CurrentSession.IncompleteTasks.Add(CurrentSession.ActiveTask);
                CurrentSession.ActiveTask = CurrentSession.IncompleteTasks[0];
                CurrentSession.IncompleteTasks.RemoveAt(0);
                CurrentSession.ActiveTask.IsActive = true;
                return session = CurrentSession;
            }
            else if (CurrentSession.ActiveTask != null && CurrentSession.IncompleteTasks.Count() == 0)
            {
                MessageBox.Show("Only one task, nothing to switch to.");
                return session = CurrentSession;
            }
            else if (CurrentSession.ActiveTask == null && CurrentSession.IncompleteTasks.Count() > 0)
            {
                CurrentSession.ActiveTask = CurrentSession.IncompleteTasks[0];
                CurrentSession.IncompleteTasks.RemoveAt(0);
                CurrentSession.ActiveTask.IsActive = true;
                return session = CurrentSession;
            }
            else if (CurrentSession.ActiveTask == null && CurrentSession.IncompleteTasks.Count() == 0)
            {
                return session = CurrentSession;
            }
            return null;
        }
        private Session CancelActiveTask(Session CurrentSession)
        {
            if (GetActiveTask() != null)
            {
                WorkTask CurrentActiveTask = GetActiveTask();
                CurrentActiveTask.IsCancelled = true;
                CurrentActiveTask.EndDatetime = DateTime.Now;
                CurrentSession.CancelledTasks.Add(CurrentActiveTask);
                CurrentActiveTask.IsActive = false;
                CurrentSession.ActiveTask = null;
                return session = CurrentSession;
            }
            return null;
        }
        private Session CompleteActiveTask(Session CurrentSession)
        {
            if (GetActiveTask() != null)
            {
                WorkTask CurrentActiveTask = GetActiveTask();
                Console.WriteLine("Completion function called.");
                CurrentActiveTask.IsCompleted = true;
                CurrentActiveTask.IsActive = false;
                CurrentActiveTask.EndDatetime = DateTime.Now;
                CurrentSession.CompletedTasks.Add(CurrentActiveTask);
                CurrentSession.ActiveTask = null;
                return session = CurrentSession;
            }
            else return null;
        }
        private void WriteLabels(Session CurrentSession)
        {
            WorkTask ActiveTask = null;
            Project ActiveProject = null;

            if (CurrentSession.ActiveTask != null)
            {
                ActiveTask = CurrentSession.ActiveTask;
                if (ActiveTask.Project != null)
                {
                    ActiveProject = ActiveTask.Project;
                }
            }
            if (ActiveTask == null)
            {
                activeTaskLabel.Text = "No active task.";
                activeProjectLabel.Text = "No active project.";
            }
            else if (ActiveProject != null)
            {
                activeTaskLabel.Text = ActiveTask.Name;
                activeProjectLabel.Text = ActiveProject.Name;
            }
            else
            {
                activeTaskLabel.Text = ActiveTask.Name;
                activeProjectLabel.Text = "No affiliated project.";
            }
        }
        private string CheckStartDatetime(WorkTask task)
        {
            if (task.StartDatetime != DateTime.MinValue)
            {
                return task.StartDatetime.ToString();
            }
            else return "Not Started";
        }
        private void Report(Session CurrentSession)
        {
            string getStatus(WorkTask task)
            {
                if (task.IsCancelled == true)
                {
                    return "Cancelled";
                }
                else if (task.IsCompleted == true)
                {
                    return "Completed";
                }
                else
                {
                    return "In Progress";
                }
            }

                List<WorkTask> AllTasks = new List<WorkTask>();
            List<WorkTask> CompletedTasks = new List<WorkTask>();
            List<WorkTask> TasksInProgress = new List<WorkTask>();
            List<WorkTask> CancelledTasks = new List<WorkTask>();

            string ReportFilePath = @".\goldfishbrainreport.txt";
            string SaveFilePath = @".\gfbsave.txt"; 
            string line = "";



            if (CurrentSession.CompletedTasks.Count > 0)
            {
                CompletedTasks = CurrentSession.CompletedTasks;
            }
            if (CurrentSession.IncompleteTasks.Count > 0)
            {
                TasksInProgress = CurrentSession.IncompleteTasks;
                if(CurrentSession.ActiveTask != null)
                {
                    TasksInProgress.Add(CurrentSession.ActiveTask);
                }
            }
            if (CurrentSession.CancelledTasks.Count > 0)
            {
                CancelledTasks = CurrentSession.CancelledTasks;
            }

            foreach (WorkTask task in CompletedTasks)
            {
                AllTasks.Add(task);
            }
            foreach (WorkTask task in CancelledTasks)
            {
                AllTasks.Add(task);
            }
            foreach (WorkTask task in TasksInProgress)
            {
                AllTasks.Add(task);
            }

            line = "Session Information\n Start: " + CurrentSession.StartDatetime + "\t End: " + CurrentSession.EndDatetime + "\t Elapsed: " + CurrentSession.ElapsedTime;

            line = line + ("\n\nTasks") + "\nTask\tStatus\tProject\tSubmitted\tStarted\tStopped\tElapsed";

            foreach (WorkTask task in AllTasks)
            {
                Project AffiliatedProject = task.Project;

                if (AffiliatedProject != null)
                {
                    line = line + "\n" + task.Name + "\t" + getStatus(task) +"\t"+ AffiliatedProject.Name + "\t" + task.SubmitDatetime + "\t" + CheckStartDatetime(task) + "\t" + task.EndDatetime + "\t" + task.ElapsedTime;
                }
                else line = line + "\n" + task.Name + "\t" + getStatus(task) + "\t" + "No Project" + "\t" + task.SubmitDatetime + "\t" + CheckStartDatetime(task) + "\t" + task.EndDatetime + "\t" + task.ElapsedTime;
            }
            File.WriteAllText(ReportFilePath, line);

            string WriteActiveTask()
            {
                if (GetActiveTask() != null)
                {
                    String SessionInfo = CurrentSession.StartDatetime + "|" + CurrentSession.ElapsedTime + "|" + CurrentSession.ActiveTask.Name + "|" + CurrentSession.ActiveTask.StartDatetime + "|" + CurrentSession.ActiveTask.ElapsedTime;
                    return SessionInfo;
                }

                else
                {
                    String SessionInfo = CurrentSession.StartDatetime + "|" + CurrentSession.ElapsedTime + "|" + "NoActiveTask" + "||";
                    return SessionInfo;
                }
            }

            line =  WriteActiveTask();

            foreach(WorkTask task in AllTasks)
            {
                Project AffiliatedProject = task.Project;

                if (AffiliatedProject != null)
                {
                    line = line + "\n" + task.Name + "|" + getStatus(task) + "|" + AffiliatedProject.Name + "|" + task.SubmitDatetime + "|" + CheckStartDatetime(task) + "|" + task.EndDatetime + "|" + task.ElapsedTime;
                }
                else line = line + "\n" + task.Name + "|" + getStatus(task) + "|" + "noproject" + "|" + task.SubmitDatetime + "|" + CheckStartDatetime(task) + "|" + task.EndDatetime + "|" + task.ElapsedTime;
                {

                }
            }
            File.WriteAllText(SaveFilePath, line);
        }
       //private Session LoadSave(String filepath)
       //{
       //    List<String> save = File.ReadAllLines(filepath);
       //    Session NewSession = null;
       //
       //    forreach(string)
       //    if (save.Contains("NoActiveTask") == false)
       //    {
       //        NewSession.ActiveTask.Name = save[0];
       //
       //    }
       //
       //
       //}
        private void activeTaskLabel_Click(object sender, EventArgs e)
        {

        }
        private void submitTaskAndSwitchButton_Click(object sender, EventArgs e)
        {
            StopActiveTaskTimer(session);
            SubmitAndSwitch(session);
            StartActiveTaskTimer(session);
            WriteLabels(session);
        }

        private void activeTaskLabel_Click_1(object sender, EventArgs e)
        {

        }
    }
}


