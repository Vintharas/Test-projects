/*
 *  Beginning Windows 8 a App Dev
 *  Chapter 8. Data Binding
 *  #1. Exercise: Putting Dependency Properties Together
 *   
 *  Create simple dependency objects using the dependency property system
 *
 *  Using dependency objects and the dependency property system allos the Windows Runtime
 *  to use data binding.
 */

using Windows.UI.Xaml;

namespace Chapter08_DataBinding.Entities
{
    public class Person : DependencyObject
    {



        // Adding dependency properties to the dependency object via the dependency property system
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(name: "FirstName",
                                                                                                  propertyType: typeof (string),
                                                                                                  ownerType: typeof (Person),
                                                                                                  typeMetadata: new PropertyMetadata (defaultValue: string.Empty));

        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(name: "LastName",
                                                                                                 propertyType: typeof (string),
                                                                                                 ownerType: typeof (Person),
                                                                                                 typeMetadata: new PropertyMetadata (defaultValue: string.Empty));


        // It is useful to wrap the dependency properties with CLR properties so the user of the class
        // won't need to interact with it via the cumbersome SetValue and GetValue methods
        public string FirstName { get { return (string) GetValue(FirstNameProperty); } set { SetValue(FirstNameProperty, value); } }
        public string LastName { get { return (string) GetValue(LastNameProperty); } set {SetValue(LastNameProperty, value);} }

    }
}