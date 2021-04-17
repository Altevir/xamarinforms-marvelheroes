using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarvelHeroesXF.Behavior
{
    public class FlexLayoutTappedBehavior : Behavior<FlexLayout>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                nameof(Command),
                typeof(ICommand),
                typeof(FlexLayoutTappedBehavior),
                defaultBindingMode: BindingMode.OneWay);

        public ICommand Command
        {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(FlexLayout bindable)
        {

            if (bindable.BindingContext != null)
            {
                this.BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += this.OnFlexLayoutBindingChanged;
            bindable.ChildAdded += this.OnFlexLayoutChildAdded;
        }

        protected override void OnDetachingFrom(FlexLayout bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= this.OnFlexLayoutBindingChanged;
            bindable.ChildAdded -= this.OnFlexLayoutChildAdded;

            foreach (var child in bindable.Children)
            {
                if (child is View childView && childView.GestureRecognizers.Any())
                {
                    var tappedGestureRecognizers = childView.GestureRecognizers.Where(x => x is TapGestureRecognizer).Cast<TapGestureRecognizer>();
                    foreach (var tapGestureRecognizer in tappedGestureRecognizers)
                    {
                        tapGestureRecognizer.Tapped -= this.OnTapped;
                        childView.GestureRecognizers.Remove(tapGestureRecognizer);
                    }
                }
            }
        }

        private void OnFlexLayoutBindingChanged(object sender, EventArgs e)
        {
            if (sender is FlexLayout flexLayout)
            {
                this.BindingContext = flexLayout.BindingContext;
            }
        }

        private void OnFlexLayoutChildAdded(object sender, ElementEventArgs args)
        {
            if (args.Element is View view)
            {
                var tappedGestureRecognizer = new TapGestureRecognizer();
                tappedGestureRecognizer.Tapped += this.OnTapped;

                view.GestureRecognizers.Add(tappedGestureRecognizer);
            }
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (sender is BindableObject bindable && this.Command != null && this.Command.CanExecute(null))
            {
                this.Command.Execute(bindable.BindingContext);
            }
        }
    }
}
