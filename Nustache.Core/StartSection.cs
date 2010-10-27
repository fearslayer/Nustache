using System.Collections.Generic;

namespace Nustache.Core
{
    public class StartSection : Part
    {
        private readonly string _name;
        private readonly List<Part> _children = new List<Part>();

        public StartSection(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public IList<Part> Children { get { return _children; } }

        public override void Render(RenderContext context)
        {
            foreach (var value in context.GetValues(_name))
            {
                context.Push(value);

                foreach (var child in _children)
                {
                    child.Render(context);
                }

                context.Pop();
            }
        }

        #region Boring stuff

        public bool Equals(StartSection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._name, _name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(StartSection)) return false;
            return Equals((StartSection)obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return string.Format("StartSection(\"{0}\")", _name);
        }

        #endregion
    }
}