using Zenject;

namespace SpaceShooter.Views
{
    public class GameView : GameElement
    {
        [Inject]
        public ShipView ShipView { get; private set; }
        [Inject]
        public LevelView LevelView { get; private set; }
    }
}