using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class TaskManagement
    {
        ApplicationDbContext db;
        public TaskManagement(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ApplicationUser CheckUserId(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    return user;
                }
            }
            return null; // Or throw an exception;
        }
        public Task CheckTaskId(int TaskId)
        {
            var task = db.Tasks.Find(TaskId);
            if (task != null)
            {
                return task;
            }
            return null; // Or throw an exception;
        }
        //public bool AssignUserToTask(string userId, int TaskId)
        //{
        //    var user = CheckUserId(userId);
        //    var task = CheckProjectId(TaskId);
        //    if (user != null && task != null)
        //    {
        //        user.Projects.Add(task);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public ICollection<Task> GetTaskProjects(string userId)
        //{
        //    var user = CheckUserId(userId);
        //    if (user != null)
        //    {
        //        return user.Tasks;
        //    }
        //    return null; // or throw and exceptions like HttpNotFound
        //}

        //public ICollection<ApplicationUser> GetProjectUsers(int TaskId)
        //{
        //    var task = CheckProjectId(TaskId);
        //    if (task != null)
        //    {
        //        return task.ApplicationUsers;
        //    }
        //    return null;
        //}
        /// <summary>
        /// Return all projects without any assigned users
        /// </summary>
        /// <returns></returns>

    }
}