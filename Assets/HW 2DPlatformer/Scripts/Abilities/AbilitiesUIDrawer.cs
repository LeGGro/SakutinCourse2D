using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.HW_2DPlatformer.Scripts.Abilities
{
    public class AbilitiesUIDrawer : MonoBehaviour
    {
        [SerializeField] private const string OverlayAbilityObjectName = "AbilityUI";

        [SerializeField] private int _paddingRight = 10;
        [SerializeField] private int _paddingLeft = 10;
        [SerializeField] private int _paddingTop = 10;
        [SerializeField] private int _paddingBottom = 10;
        [SerializeField] private TextAnchor _childAligment = TextAnchor.LowerRight;
        [SerializeField] private GridLayoutGroup.Corner _startCorner = GridLayoutGroup.Corner.UpperRight;
        [SerializeField] private GridLayoutGroup.Axis _startAxis = GridLayoutGroup.Axis.Vertical;

        [SerializeField] Vector2 _spacing = new(10, 10);
        [SerializeField] Vector2 _cellSize = new(200, 20);

        [SerializeField] private BarBase _uiElementPrefab;
        [SerializeField] private Transform _overlayUILocation;

        public BarBase CreateUIContainer()
        {
            return Instantiate(_uiElementPrefab, _overlayUILocation);
        }

        public void AddBaseComponents()
        {
            GridLayoutGroup gridLayoutGroup = _overlayUILocation.AddComponent<GridLayoutGroup>();
            gridLayoutGroup.padding.right = _paddingRight;
            gridLayoutGroup.padding.left = _paddingLeft;
            gridLayoutGroup.padding.top = _paddingTop;
            gridLayoutGroup.padding.bottom = _paddingBottom;
            gridLayoutGroup.spacing = _spacing;
            gridLayoutGroup.childAlignment = _childAligment;
            gridLayoutGroup.startCorner = _startCorner;
            gridLayoutGroup.startAxis = _startAxis;
            gridLayoutGroup.cellSize = _cellSize;
        }
    }
}