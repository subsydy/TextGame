namespace TextGame.Entities
{
    public class Portal
    {
        private readonly Area _area1;
        private readonly Area _area2;

        public Portal(Area area1, Area area2) {
            _area1 = area1;
            _area2 = area2;
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