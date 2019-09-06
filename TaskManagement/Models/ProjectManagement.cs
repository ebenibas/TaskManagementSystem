using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class ProjectManagement
    {
        ApplicationDbContext db;
        public ProjectManagement(ApplicationDbContext db)
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
        public Project CheckProjectId(int projectId)
        {
            var project = db.Projects.Find(projectId);
            if (project != null)
            {
                return project;
            }
            return null; // Or throw an exception;
        }
        //public bool AssignUserToProject(string userId, int projectId)
        //{
        //    var user = CheckUserId(userId);
        //    var project = CheckProjectId(projectId);
        //    if (user != null && project != null)
        //    {
        //        user.Projects.Add(project);
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
        public ICollection<UserProject> GetUserProjects(string userId)
        {
            var user = CheckUserId(userId);
            if (user != null)
            {
                return user.Projects;
            }
            return null; // or throw and exceptions like HttpNotFound
        }

        //public ICollection<ApplicationUser> GetProjectUsers(int projectId)
        //{
        //    var project = CheckProjectId(projectId);
        //    if (project != null)
        //    {
        //        return project.ApplicationUsers;
        //    }
        //    return null;
        //}
        /// <summary>
        /// Return all projects without any assigned users
        /// </summary>
        /// <returns></returns>
        public List<Project> GetNewProjects()
        {
            var allProjects = db.Projects.ToList();
            return allProjects.Where(p => p.ApplicationUsers.Count() == 0).ToList();
        }
    }
}