using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class TreeOfGameObjects : IEnumerable<Node>
    {
        #region Fields
        Node _root;
        #endregion

        #region Fields
        public Node Root => _root;
        #endregion

        public TreeOfGameObjects(Node root)
        {
            _root = root;
        }
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
    }
}
