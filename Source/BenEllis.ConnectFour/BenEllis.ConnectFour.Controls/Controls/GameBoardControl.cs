using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using BenEllis.ConnectFour.Game;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace BenEllis.ConnectFour.Controls
{
    [TemplatePart(Name = GameBoardGridPartName, Type = typeof(Grid))]
    [TemplatePart(Name = PiecesPartName,        Type = typeof(ItemsControl))]
    public sealed class GameBoardControl : Control
    {
        public const string GameBoardGridPartName = "PART_GameBoardGrid";
        public const string PiecesPartName        = "PART_Pieces";

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

        public static readonly DependencyProperty ColumnSelectedCommandProperty = DependencyProperty.Register("ColumnSelectedCommand", typeof (ICommand), typeof (GameBoardControl), new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty SelectedColProperty           = DependencyProperty.Register("SelectedCol"          , typeof (int)      , typeof (GameBoardControl), new PropertyMetadata(default(int)));

        public static readonly DependencyProperty SlotsProperty = DependencyProperty.Register("Slots", typeof(IEnumerable), typeof(GameBoardControl), new PropertyMetadata(default(ObservableCollection<object>), OnSlotsPropertyChanged));

        public static readonly DependencyProperty SlotValueConverterProperty = DependencyProperty.Register("SlotValueConverter", typeof (IValueConverter), typeof (GameBoardControl), new PropertyMetadata(default(IValueConverter)));

        private static void OnSlotsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GameBoardControl control = (GameBoardControl) d;

            IEnumerable oldValue = (IEnumerable) e.OldValue;
            IEnumerable newValue = (IEnumerable) e.NewValue;

            INotifyCollectionChanged oldObservableCollection = oldValue as INotifyCollectionChanged;
            INotifyCollectionChanged newObservableCollection = newValue as INotifyCollectionChanged;

            if (oldObservableCollection != null)
                oldObservableCollection.CollectionChanged -= control.OnSlotsCollectionChanged;
            if (newObservableCollection != null)
                newObservableCollection.CollectionChanged += control.OnSlotsCollectionChanged;
        }

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

        public ICommand ColumnSelectedCommand
        {
            get { return (ICommand)GetValue(ColumnSelectedCommandProperty); }
            set { SetValue(ColumnSelectedCommandProperty, value); }
        }

        public int SelectedCol
        {
            get { return (int) GetValue(SelectedColProperty); }
            set { SetValue(SelectedColProperty, value); }
        }

        public IEnumerable Slots
        {
            get { return (IEnumerable) GetValue(SlotsProperty); }
            set { SetValue(SlotsProperty, value); }
        }

        public IValueConverter SlotValueConverter
        {
            get { return (IValueConverter)GetValue(SlotValueConverterProperty); }
            set { SetValue(SlotValueConverterProperty, value); }
        }

#endregion

        private readonly ObservableCollection<FrameworkElement> _pieceCollection; 

        private Grid _gameBoardGrid;
        private ItemsControl _pieces;

        private readonly Storyboard[] _storyboards;
        private int _nextStoryboard; 

        public GameBoardControl()
        {
            DefaultStyleKey = typeof(GameBoardControl);
            _pieceCollection = new ObservableCollection<FrameworkElement>();

            _storyboards = new Storyboard[10];
            for (int i = 0; i < _storyboards.Length; i++)
            {
                DoubleAnimation animation = new DoubleAnimation { FillBehavior = FillBehavior.HoldEnd };
                Storyboard.SetTargetProperty(animation, "(Canvas.Top)");
                _storyboards[i] = new Storyboard
                {
                    FillBehavior = FillBehavior.HoldEnd,
                    Children = { animation }
                };
            }

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private DispatcherTimer _timer;
        private readonly Random _random = new Random();

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _pieceCollection.Clear();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.2)
            };

            int i = 0;
            _timer.Tick += (o, e2) =>
            {
                GameBoardSlotValue value = _random.Next(2) == 1 ? GameBoardSlotValue.Player1 : GameBoardSlotValue.Player2;
                OnSlotsCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, null, i));
                ++i;
                if(i >= Columns * Rows)
                    _timer.Stop();
            };
            _timer.Start();
        }

        protected override void OnApplyTemplate()
        {
            _gameBoardGrid = (Grid) GetTemplateChild(GameBoardGridPartName);
            _gameBoardGrid.PointerReleased += GameBoardGridOnPointerReleased;

            _pieces = (ItemsControl) GetTemplateChild(PiecesPartName);
            _pieces.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = _pieceCollection });
            base.OnApplyTemplate();
        }

        private void GameBoardGridOnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(_gameBoardGrid);
            var x = point.Position.X - BoardPadding.Left;
            if (x < 0) return;
            int col = (int) (x / (SlotSize + SlotPadding));
            if (col >= Columns) return;
            SelectedCol = col;
            if(ColumnSelectedCommand?.CanExecute(col) == true)
                ColumnSelectedCommand?.Execute(col);
        }

        private void OnSlotsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Replace)
                return;

            GameBoardSlotValue value;
            object valueItem = e.NewItems[0];
            if (!(valueItem is GameBoardSlotValue))
            {
                var converter = SlotValueConverter;
                if (converter == null)
                    throw new InvalidOperationException($"Slots collection has value type {valueItem.GetType()} and no SlotValueConverter is supplied, required type is {typeof(GameBoardSlotValue).Name}");
                value = (GameBoardSlotValue)converter.Convert(valueItem, typeof(GameBoardSlotValue), null, Language);
            }
            else
            {
                value = (GameBoardSlotValue)valueItem;
            }

            var boardPadding = BoardPadding;
            var slotSize = SlotSize;
            var slotPadding = SlotPadding;

            BoardLocation location = GameUtils.GetLocation(e.NewStartingIndex, Columns, Rows);
            Point pieceTargetPosition = GameUtils.GetPosition(location, boardPadding.Left, boardPadding.Top, slotSize, slotPadding);

            // Canvas positions element with top/left as position, ajust target position from calculated center position
            pieceTargetPosition.X -= slotSize / 2;
            pieceTargetPosition.Y -= slotSize / 2;

            Canvas piece = CreatePiece(value, slotSize);

            Canvas.SetLeft(piece, pieceTargetPosition.X);
            Canvas.SetTop(piece, pieceTargetPosition.Y);

            _pieceCollection.Add(piece);

            Storyboard storyboard = GetNextStoryboard();
            DoubleAnimation animation = (DoubleAnimation)storyboard.Children[0];
            SetAnimationProperties(animation, piece, -slotSize, pieceTargetPosition.Y, 500.0);
            storyboard.Begin();
        }

        private Canvas CreatePiece(GameBoardSlotValue value, double slotSize)
        {
            return new Canvas
            {
                Width = slotSize,
                Height = slotSize,
                Children =
                {
                    new Ellipse
                    {
                        Fill   = value == GameBoardSlotValue.Player1 ? PlayerOneBrush : PlayerTwoBrush,
                        Width  = slotSize,
                        Height = slotSize,
                    },
                    new Ellipse
                    {
                        Stroke   = value == GameBoardSlotValue.Player1 ? PlayerOneDetailsBrush : PlayerTwoDetailsBrush,
                        Width  = slotSize - 5,
                        Height = slotSize - 5,
                        Margin = new Thickness(2.5)
                    }
                }
            };
        }

        private Storyboard GetNextStoryboard()
        {
            Storyboard storyboard = _storyboards[_nextStoryboard];
            storyboard.SkipToFill();
            storyboard.Stop();
            _nextStoryboard = (_nextStoryboard + 1) % _storyboards.Length;
            return storyboard;
        }

        private static void SetAnimationProperties(DoubleAnimation animation, DependencyObject target, double from, double to, double pointsPerSecond)
        {
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds((to - from)/pointsPerSecond));
            Storyboard.SetTarget(animation, target);
        }
    }
}
