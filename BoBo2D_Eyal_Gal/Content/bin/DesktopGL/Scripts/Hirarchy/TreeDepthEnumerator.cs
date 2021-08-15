using System.Collections;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public class TreeDepthEnumerator : IEnumerator<Node>//treeStructure of nodes that has gameObjects
    {
        #region Field
        Stack<int> _cache;
        Node _current = null;
        TreeOfGameObjects _tree;

        bool _reachedEnd = false;
        #endregion

        #region Properties
        public Node Current => _current;

        //Gets the element in the collection at the current position of the enumerator.
        object IEnumerator.Current => _current;
        #endregion

        #region Constructor
        public TreeDepthEnumerator(TreeOfGameObjects collection)
        {
            _tree = collection;
            _cache = new Stack<int>();
        }
        #endregion

        #region Methods
        //run the algorithem for every root?
        public bool MoveNext()
        {
            //Advances the enumerator to the next element of the collection.
            if (_reachedEnd)
                return false;

            //were at the begining
            if (_cache.Count == 0)
            {
                _current = _tree.Root;
                _cache.Push(0);
                return true;
            }

            var context = _cache.Pop();

            while (context >= _current.Children.Count)
            {
                _current = _current.Parant;

                if (_current == null)
                {
                    _reachedEnd = true;
                    return false;
                }

                context = _cache.Pop();
            }

            _current = _current.Children[context++];
            _cache.Push(context);
            _cache.Push(0);

            return true;
        }

        //reset to first root?
        public void Reset()
        {
            //Sets the enumerator to its initial position, which is before the first element in the collection.
            _reachedEnd = false;
            _current = default(Node);
        }

        public void Dispose()
        {
            //Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        }
        #endregion

        //go on first node, after that go down on all nodes if you get to a leaf, go back

        //  root       1
        //           /   \
        //          2     5
        //         / \   / \
        //  leaf  3   4 6
        //             /
        //            7
        //check root node if it is the game object
        //if not move next to second node and start recursive action per level of the hyrarchi
    }
}
