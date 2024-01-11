namespace DevOps_Levels_1
{
    using System;

    using Skyline.DataMiner.Analytics.GenericInterface;

    [GQIMetaData(Name = "GQIO - DevOpsLevel")]
    public class DevOpsLevelOperator : IGQIInputArguments, IGQIColumnOperator, IGQIRowOperator
    {
        // Thresholds:
        private const int Advocate_Threshold = 750;
        private const int Enabler_Threshold = 5000;
        private const int Catalyst_Threshold = 25000;

        private readonly GQIColumnDropdownArgument _devOpsPointsColumnArg; // Input Argument to be requested from the user;
        private readonly GQIStringColumn _devOpsLevelColumn; // New Column to be added;

        private GQIColumn _devOpsPointsColumn;

        public DevOpsLevelOperator()
        {
            _devOpsPointsColumnArg = new GQIColumnDropdownArgument("DevOps Points")
            {
                IsRequired = true,
                Types = new[] { GQIColumnType.Int, GQIColumnType.Double }, // Want both int and double columns to be suggested;
            };

            _devOpsLevelColumn = new GQIStringColumn("DevOps Level");
        }

        public GQIArgument[] GetInputArguments()
        {
            return new GQIArgument[] { _devOpsPointsColumnArg };
        }

        public void HandleColumns(GQIEditableHeader header)
        {
            header.AddColumns(_devOpsLevelColumn);
        }

        public void HandleRow(GQIEditableRow row)
        {
            int devOpsPoints = Convert.ToInt32(row.GetValue<double>(_devOpsPointsColumn));
            string devOpsLevel = GetDevOpsLevel(devOpsPoints);

            row.SetValue(_devOpsLevelColumn, devOpsLevel);
        }

        public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
        {
            _devOpsPointsColumn = args.GetArgumentValue(_devOpsPointsColumnArg); // Getting Input argument value;
            return default;
        }

        private static string GetDevOpsLevel(int devOpsPoints)
        {
            string level;
            if (devOpsPoints >= Catalyst_Threshold)
            {
                level = "Catalyst";
            }
            else if (devOpsPoints >= Enabler_Threshold)
            {
                level = "Enabler";
            }
            else if (devOpsPoints >= Advocate_Threshold)
            {
                level = "Advocate";
            }
            else
            {
                level = "Member";
            }

            return level;
        }
    }
}