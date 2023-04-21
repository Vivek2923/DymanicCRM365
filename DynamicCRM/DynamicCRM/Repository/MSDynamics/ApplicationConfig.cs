
namespace UoPeople.NGPortal.Service.Settings
{
    public class ApplicationConfig
    {
        // Duration after new PA assignment for which new PA flag should be shown in Student dashboard support tab.
        public Int16 NewPADurationInDays { get; init; }
        public Int16 MaximumInactiveTerms { get; init; }

    }
}