namespace Api_Web_Ejemplo.Controllers.Models
{
    public class TreeNode<T>
    {
        public T  Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value) {
            Value = value;
            Children = new List<TreeNode<T>>(); 
        }

    }
}
