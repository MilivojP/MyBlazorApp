//using MyBlazorApp.Server.Interfaces;
//using MyBlazorApp.Server.Models;
//using MyBlazorApp.Shared.Models;
//using Microsoft.EntityFrameworkCore;

//namespace MyBlazorApp.Server.Services
//{
//    public class WorkTimeServices :IWorkTimeServices

//    {
//        readonly DatabaseContext _dbContextWork = new();

//        public WorkTimeServices(DatabaseContext dbContextWork)
//        {
//            _dbContextWork = dbContextWork;
//        }

//        //To Get all user details
//        public List<WorkTime> GetUWorkTimeDetails()
//        {
//            try
//            {
//                return _dbContextWork.WorkTime.ToList();
//                //_dbContext.WorkTime.ToList();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //To Add new user record
//        public void AddWorkTime(WorkTime UserName)
//        {
//            try
//            {
//                _dbContextWork.WorkTime.Add(UserName);
//                _dbContextWork.SaveChanges();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //To Update the records of a particluar user
//        public void UpdateWorkTimeDetails(WorkTime UserName)
//        {
//            try
//            {
//                _dbContextWork.Entry(UserName).State = EntityState.Modified;
//                _dbContextWork.SaveChanges();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //Get the details of a particular user
//        public User GetWorkTimeData(int id)
//        {
//            try
//            {
//                WorkTime? UserId= _dbContextWork.WorkTime.Find(UserId);
//                if (UserId != null)
//                {
//                    return UserId;
//                }
//                else
//                {
//                    throw new ArgumentNullException();
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //To Delete the record of a particular user
//        public void DeleteWorkTime(int id)
//        {
//            try
//            {
//                WorkTime? UserId = _dbContextWork.WorkTime.Find(UserId);
//                if (UserId != null)
//                {
//                    _dbContextWork.WorkTime.Remove(UserId);
//                    _dbContextWork.SaveChanges();
//                }
//                else
//                {
//                    throw new ArgumentNullException();
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        WorkTime IWorkTimeServices.GetWorkTimeData(int UserId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

