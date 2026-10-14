namespace TaskManager.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }         // 分类名：工作/学习/生活
        public string Color { get; set; }        // 颜色标记

        // 导航属性：一个分类下有多个任务
        public List<TaskItem> Tasks { get; set; }
    }
}
