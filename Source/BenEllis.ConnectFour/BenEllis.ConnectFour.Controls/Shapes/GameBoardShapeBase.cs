using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace BenEllis.ConnectFour.Shapes
{
    public abstract class GameBoardShapeBase : Path
    {
        public static readonly DependencyProperty ColumnsProperty           = DependencyProperty.Register("Columns"          , typeof (int)      , typeof (GameBoardShapeBase), new PropertyMetadata(default(int)));
        public static readonly DependencyProperty RowsProperty              = DependencyProperty.Register("Rows"             , typeof (int)      , typeof (GameBoardShapeBase), new PropertyMetadata(default(int)));
        public static readonly DependencyProperty SlotSizeProperty          = DependencyProperty.Register("SlotSize"         , typeof (double)   , typeof (GameBoardShapeBase), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty SlotPaddingProperty       = DependencyProperty.Register("SlotPadding"      , typeof (double)   , typeof (GameBoardShapeBase), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty BoardCornerRadiusProperty = DependencyProperty.Register("BoardCornerRadius", typeof (double)   , typeof (GameBoardShapeBase), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty BoardPaddingProperty      = DependencyProperty.Register("BoardPadding"     , typeof (Thickness), typeof (GameBoardShapeBase), new PropertyMetadata(default(Thickness)));

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public double SlotSize
        {
            get { return (double) GetValue(SlotSizeProperty); }
            set { SetValue(SlotSizeProperty, value); }
        }

        public double SlotPadding
        {
            get { return (double) GetValue(SlotPaddingProperty); }
            set { SetValue(SlotPaddingProperty, value); }
        }

        public double BoardCornerRadius
        {
            get { return (double) GetValue(BoardCornerRadiusProperty); }
            set { SetValue(BoardCornerRadiusProperty, value); }
        }

        public Thickness BoardPadding
        {
            get { return (Thickness) GetValue(BoardPaddingProperty); }
            set { SetValue(BoardPaddingProperty, value); }
        }

        private Size _geometrySize;

        protected GameBoardShapeBase()
        {
            RegisterPropertyChangedCallback(ColumnsProperty          , RenderAffectingPropertyChanged);
            RegisterPropertyChangedCallback(RowsProperty             , RenderAffectingPropertyChanged);
            RegisterPropertyChangedCallback(SlotSizeProperty         , RenderAffectingPropertyChanged);
            RegisterPropertyChangedCallback(SlotSizeProperty         , RenderAffectingPropertyChanged);
            RegisterPropertyChangedCallback(BoardCornerRadiusProperty, RenderAffectingPropertyChanged);
            RegisterPropertyChangedCallback(BoardPaddingProperty     , RenderAffectingPropertyChanged);
            Loaded += (sender, args) => SetGeometry();
        }

        private void RenderAffectingPropertyChanged(DependencyObject o, DependencyProperty e)
        {
            (o as GameBoardShapeBase)?.SetGeometry();
        }

        private void SetGeometry()
        {
            Geometry geometry = BuildGeometry();
            _geometrySize = new Size(geometry.Bounds.Width, geometry.Bounds.Height);
            Data = geometry;
            InvalidateMeasure();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Debug.WriteLine(_geometrySize);

            return _geometrySize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return _geometrySize;
        }

        protected abstract Geometry BuildGeometry();
    }
}