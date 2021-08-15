using System.Collections;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public class TreeOfGameObjects : IEnumerable<Node>
    {
        #region Fields
        Node _root;
        #endregion

        #region Properties
        public Node Root => _root;
        #endregion

        #region Constructor
        public TreeOfGameObjects(Node root)
        {
            _root = root;
        }
        #endregion

        #region Methods
        public IEnumerator<Node> GetEnumerator()
        {
            return new TreeDepthEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void DestroyTree()
        {
            GameObjectManager.Instance.Hirarchy.Remove(this);
        }
        #endregion
    }
}
