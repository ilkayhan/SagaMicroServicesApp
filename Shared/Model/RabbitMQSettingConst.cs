using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class RabbitMQSettingConst
    {
        public const string BalanceCheckEventQueueName_Step1 = "balance-check-event-queue-step-1";
        public const string BalanceCheckSuccessEventQueueName_Step2 = "balance-check-success-event-queue-step-2";
        public const string TransferSuccesedEventQueueName_Step3 = "transfer-successed-event-queue-step-3";
        public const string AuiditLogEventQueueName_Step4 = "auidit-log-event-queue-step-4";
        public const string FailTransferBalanceFix_Step5 = "fail-transfer-balance-fix-step-5";
    }
}