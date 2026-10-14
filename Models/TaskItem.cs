namespace TaskManager.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }          // 任务标题
        public string Description { get; set; }    // 任务描述
        public bool IsCompleted { get; set; }      // 是否完成
        public DateTime CreatedAt { get; set; }    // 创建时间

        // 外键：属于哪个用户
        public int UserId { get; set; }
        public User User { get; set; }             // 导航属性

        // 外键：属于哪个分类
        public int CategoryId { get; set; }
        public Category Category { get; set; }     // 导航属性
    }
}
