namespace GlobalMap
{
    using UnityEngine;

    public class Hero : MonoBehaviour, IHero
    {
        public HeroState State { get; set; }

        private Vector2 _heroPosition;
        public Vector2 HeroPosition
        {
            get { return _heroPosition; }
            set {
                _heroPosition = value;
                transform.position = value;
            }
        }

        public Transform GetTransform()
        {
            return gameObject.transform;
        }
    }
}