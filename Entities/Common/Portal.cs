namespace TextGame.Entities.Common
{
    public class Portal : IEntity
    {
        private Area _area1;
        private Area _area2;

        private Portal() { }

        public string Name { get; private set; }
        public bool IsKnown { get; set; }

        public static Portal FromTo(Area from, Area to)
        {
            return new Portal 
            { 
                _area1 = from,
                _area2 = to,
                IsKnown = true
            };
        }

        public Area OtherSide(Area thisOne) {
            if(_area1 != thisOne && _area2 != thisOne) {
                throw new System.Exception("This area isn't attached to the portal.");
            }

            if(_area1 != thisOne) return _area1;
            return _area2;
        }
    }
}