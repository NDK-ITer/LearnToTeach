using MeetingServer.DTOs;

namespace MeetingServer.SignalR
{
    public class PresenceTracker
    {
        /// <summary>
        /// List user is connecting
        /// </summary>
        private 
            static 
            readonly 
            Dictionary<UserConnectionInfo, List<string>> 
            OnlineUsers = new Dictionary<UserConnectionInfo, List<string>>();

        /// <summary>
        /// When user connect to Server. User will be added to 'OnlineUsers'
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public Task<bool> UserConnected(UserConnectionInfo user, string connectionId)
        {
            bool isOnline = false;
            lock (OnlineUsers)
            /*
                "lock (OnlineUsers){}" có thể ám chỉ việc 
                sử dụng khóa để đảm bảo rằng chỉ một luồng 
                có thể truy cập vào danh sách "OnlineUsers" tại một thời điểm nhất định. 
                Điều này giúp đồng bộ hóa truy cập và tránh xung đột dữ liệu 
                khi có nhiều luồng cùng thao tác trên danh sách này.
             */
            {
                var temp = OnlineUsers.FirstOrDefault(x => x.Key.UserName == user.UserName && x.Key.ClassroomId == user.ClassroomId);

                if (temp.Key == null)//chua co online
                {
                    OnlineUsers.Add(user, new List<string> { connectionId });
                    isOnline = true;
                }
                else if (OnlineUsers.ContainsKey(temp.Key))
                {
                    OnlineUsers[temp.Key].Add(connectionId);
                }
            }

            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(UserConnectionInfo user, string connectionId)
        {
            bool isOffline = false;
            lock (OnlineUsers)
            {
                var temp = OnlineUsers.FirstOrDefault(x => x.Key.UserName == user.UserName && x.Key.ClassroomId == user.ClassroomId);
                if (temp.Key == null)
                    return Task.FromResult(isOffline);

                OnlineUsers[temp.Key].Remove(connectionId);
                if (OnlineUsers[temp.Key].Count == 0)
                {
                    OnlineUsers.Remove(temp.Key);
                    isOffline = true;
                }
            }

            return Task.FromResult(isOffline);
        }
        /// <summary>
        /// To get all user is connecting in classroom
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        public Task<List<UserConnectionInfo>> GetOnlineUsers(string classroomId)
        {
            List<UserConnectionInfo> onlineUsers;
            lock (OnlineUsers)
            {
                onlineUsers = OnlineUsers.Where(u => u.Key.ClassroomId == classroomId).Select(k => k.Key).ToList();
            }

            return Task.FromResult(onlineUsers);
        }
        /// <summary>
        /// To get all connection of user is connecting
        /// </summary>
        /// <param name="user">UserConnectionInfo</param>
        /// <returns></returns>
        public Task<List<string>> GetConnectionsForUser(UserConnectionInfo user)
        {
            List<string> connectionIds = new List<string>();
            lock (OnlineUsers)
            {
                var temp = OnlineUsers.SingleOrDefault(x => x.Key.UserName == user.UserName && x.Key.ClassroomId == user.ClassroomId);
                if (temp.Key != null)
                {
                    connectionIds = OnlineUsers.GetValueOrDefault(temp.Key);
                }
            }
            return Task.FromResult(connectionIds);
        }
        /// <summary>
        /// To get all connection of user is connecting with user name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<List<string>> GetConnectionsForUsername(string username)
        {
            List<string> connectionIds = new List<string>();
            lock (OnlineUsers)
            {
                // 1 user co nhieu lan dang nhap
                var listTemp = OnlineUsers.Where(x => x.Key.UserName == username).ToList();
                if (listTemp.Count > 0)
                {
                    foreach (var user in listTemp)
                    {
                        connectionIds.AddRange(user.Value);
                    }
                }
            }
            return Task.FromResult(connectionIds);
        }
    }
}
