﻿namespace Shared.Model
{
    public class Account
    {
        public long Id { get; set; } // Hesap ID'si
        public string AccountHolderName { get; set; } // Hesap sahibi adı
        public decimal Balance { get; set; } // Hesap bakiyesi
        public string Currency { get; set; } // Para birimi (ör: TRY, USD)
        public DateTime CreatedAt { get; set; } // Hesap oluşturulma tarihi
    }
}