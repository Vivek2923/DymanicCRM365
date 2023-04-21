namespace UoPeople.NGPortal.Utility
{
    public static class Constants
    {
        public static class Messages
        {
            public const string ApplicationError = "Error accessing api...";
        }
        public static class ApplicationGuid
        {
            //new_registrationstatusid  
            public const string regStatusOpen = "BC6EB3B1-A39A-DF11-9426-000C2930D715";
            public const string regStatusClosed = "62FBCDBE-A39A-DF11-9426-000C2930D715";
            public const string regStatusCancelled = "63FBCDBE-A39A-DF11-9426-000C2930D715";
            public const string proctoredRequiredCourse = "E2F1887C-84B7-E011-9C8C-00155D00CE15";
            //new_registrationsubstatusid
            public const string regSubStatusRegistered = "628FB7FA-A89A-DF11-9426-000C2930D715";
            public const string regSubStatusProcessingReq = "ECCDC307-A99A-DF11-9426-000C2930D715";
            public const string regSubStatusReqPending = "DE3EC814-44DF-DF11-9B24-00155D00111B";
            public const string regSubStatusGraded = "EE0CCB37-A99A-DF11-9426-000C2930D715";
            //new_registrationsubstatusreasonid 
            public const string regSubStatusReasonPendingPreReq = "2374CBFE-45DF-DF11-9B24-00155D00111B";//"Pending successful completion of prerequisite(s)"
            //new_proctorstatusid - this field actually points to proctor sub status. Great Naming.
            public const string procSubStatusApproved = "0EDAAD4F-E4B1-E011-9C8C-00155D00CE15";//The proctor has approved your request to proctor his exam
            public const string procSubStatusNotAssigned = "3F8E73AC-03BD-E011-9C8C-00155D00CE15";//No proctor assigned yet
            public const string procSubStatusPendingProcApproval = "0D6250EC-7CB3-E011-9C8C-00155D00CE15";//Pending approval of proctor to proctor this exam
            //new_finalgradeid
            public const string regFinalGradeDropped = "3EE11F86-3899-DF11-9426-000C2930D715";
            public const string regFinalGradeWithDrawal = "3FE11F86-3899-DF11-9426-000C2930D715";
        }
        public static class StatusConstants
        {
            public const string tranStatusOpen = "1";
            public const string tranStatusClosed = "3";
            //new_transactionstatusreason
            public const string tranSubStatusFutureDue = "11";
            public const string tranSubStatusDueNow = "7";
            public const string tranSubStatusOverDue = "8";
            public const string tranSubStatusPaid = "2";
        }
        public static class ApplicationConstants
        {
            public const string StandingSAP = "4";
            public const string ProgramTypeDegree = "1";
            public const string NDSSTypeStudent = "NDSS";
            public const string StudentStatusGraduated = "Graduated";
            public const string FoundationProgram = "100000000";
            public const string FoundationTransferCreditProgram = "100000001";
            public const string EasentToStudentYes = "100000000";
            public const string ConfirmdEnrollmentYes = "100000000";
            public const string ConfirmdEnrollmentNo = "100000001";
            public const string DegreeProgramGroup = "100000000";
            public const string CountryCode = "US";

        }
        public static class GlobalVariables
        {
            public const int ChecklistHighPriorityThreshold = 6;
            public const int ChecklistMediumPriorityThreshold = 14;
            public const int ChecklistLowPriorityThreshold = 21;
        }

        public static class NotificationConstants
        {
            public const string DropNotificationTitle = "dropNotification_title";
            public const string DropNotificationdesc = "dropNotification_desc";
            public const string WithDrawalNotificationTitle = "withDrawalNotification_title";
            public const string WithDrawalNotificationdesc = "withDrawalNotification_desc";
            public const string EarlyRegNotificationTitle = "earlyRegNotification_title";
            public const string EarlyRegNotificationdesc = "earlyRegNotification_desc";
            public const string LateRegNotificationTitle = "lateRegNotification_title";
            public const string LateRegNotificationdesc = "lateRegNotification_desc";
            public const string ProctorNotificationTitle = "proctorNotification_title";
            public const string ProctorNotificationdesc = "proctorNotification_desc";
            public const string PaymentDeadlineNotificationTitle = "paymentDeadlineNotification_title";
            public const string PaymentDeadlineNotificationdesc = "paymentDeadlineNotification_desc";
            public const string ShowExamNotificationTitle = "showExamNotification_title";
            public const string ShowExamNotificationdesc = "ShowExamNotification_desc";
        }

    }
}