namespace TaskManager.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }    // 用户名
        public string Email { get; set; }        // 邮箱
        public DateTime CreatedAt { get; set; }  // 创建时间

        // 导航属性：一个用户有多个任务
        public List<TaskItem> Tasks { get; set; }
    }
}
