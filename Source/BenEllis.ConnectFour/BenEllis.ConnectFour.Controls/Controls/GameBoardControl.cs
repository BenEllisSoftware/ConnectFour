using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace BenEllis.ConnectFour.Controls
{
    public sealed class GameBoardControl : Control
    {
#region Dependency properties

        public static readonly DependencyProperty RowsProperty              = DependencyProperty.Register("Rows"             , typeof (int)      , typeof (GameBoardControl), new PropertyMetadata(default(int)));
        public static readonly DependencyProperty ColumnsProperty           = DependencyProperty.Register("Columns"          , typeof (int)      , typeof (GameBoardControl), new PropertyMetadata(default(int)));
        public static readonly DependencyProperty SlotSizeProperty          = DependencyProperty.Register("SlotSize"         , typeof (double)   , typeof (GameBoardControl), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty SlotPaddingProperty       = DependencyProperty.Register("SlotPadding"      , typeof (double)   , typeof (GameBoardControl), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty BoardCornerRadiusProperty = DependencyProperty.Register("BoardCornerRadius", typeof (double)   , typeof (GameBoardControl), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty BoardPaddingProperty      = DependencyProperty.Register("BoardPadding"     , typeof (Thickness), typeof (GameBoardControl), new PropertyMetadata(default(Thickness)));

        public static readonly DependencyProperty BoardBrushProperty            = DependencyProperty.Register("BoardBrush"           , typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty BoardDetailsBrushProperty     = DependencyProperty.Register("BoardDetailsBrush"    , typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty PlayerOneBrushProperty        = DependencyProperty.Register("PlayerOneBrush"       , typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty PlayerOneDetailsBrushProperty = DependencyProperty.Register("PlayerOneDetailsBrush", typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty PlayerTwoBrushProperty        = DependencyProperty.Register("PlayerTwoBrush"       , typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty PlayerTwoDetailsBrushProperty = DependencyProperty.Register("PlayerTwoDetailsBrush", typeof (Brush), typeof (GameBoardControl), new PropertyMetadata(default(Brush)));

        public int Rows
        {
            get { return (int) GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public int Columns
        {
            get { return (int) GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public double SlotSize
        {
            get { return (double)GetValue(SlotSizeProperty); }
            set { SetValue(SlotSizeProperty, value); }
        }

        public double SlotPadding
        {
            get { return (double)GetValue(SlotPaddingProperty); }
            set { SetValue(SlotPaddingProperty, value); }
        }

        public double BoardCornerRadius
        {
            get { return (double)GetValue(BoardCornerRadiusProperty); }
            set { SetValue(BoardCornerRadiusProperty, value); }
        }

        public Thickness BoardPadding
        {
            get { return (Thickness)GetValue(BoardPaddingProperty); }
            set { SetValue(BoardPaddingProperty, value); }
        }

        public Brush BoardBrush
        {
            get { return (Brush)GetValue(BoardBrushProperty); }
            set { SetValue(BoardBrushProperty, value); }
        }

        public Brush BoardDetailsBrush
        {
            get { return (Brush) GetValue(BoardDetailsBrushProperty); }
            set { SetValue(BoardDetailsBrushProperty, value); }
        }

        public Brush PlayerOneBrush
        {
            get { return (Brush) GetValue(PlayerOneBrushProperty); }
            set { SetValue(PlayerOneBrushProperty, value); }
        }

        public Brush PlayerOneDetailsBrush
        {
            get { return (Brush) GetValue(PlayerOneDetailsBrushProperty); }
            set { SetValue(PlayerOneDetailsBrushProperty, value); }
        }

        public Brush PlayerTwoBrush
        {
            get { return (Brush) GetValue(PlayerTwoBrushProperty); }
            set { SetValue(PlayerTwoBrushProperty, value); }
        }

        public Brush PlayerTwoDetailsBrush
        {
            get { return (Brush) GetValue(PlayerTwoDetailsBrushProperty); }
            set { SetValue(PlayerTwoDetailsBrushProperty, value); }
        }

#endregion

        public GameBoardControl()
        {
            DefaultStyleKey = typeof(GameBoardControl);
        }
    }
}
