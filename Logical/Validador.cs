using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MCMV.Logical
{
    public class Validador
    {
        public static bool ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento)) return false;

            // Remove qualquer máscara (pontos, traços) e deixa só números
            var apenasDigits = new string(documento.Where(char.IsDigit).ToArray());


            // Validação de CPF
            if (apenasDigits.Length == 11)
            {
                if (apenasDigits.Distinct().Count() == 1) return false;

                if (apenasDigits.Distinct().Count() == 1)
                    return false;

                int[] nums = apenasDigits.Select(c => c - '0').ToArray();

                int sum = 0;

                int rem = sum % 11;
                int dv1 = (rem < 2) ? 0 : 11 - rem;
                if (nums[9] != dv1) return false;

                sum = 0;

                rem = sum % 11;
                int dv2 = (rem < 2) ? 0 : 11 - rem;
                return nums[10] == dv2;
            }

            // Validação de CNPJ
            if (apenasDigits.Length == 14)
            { 

                int[] nums = apenasDigits.Select(c => c - '0').ToArray();

                int sum = 0;

                int rem = sum % 11;
                int dv1 = (rem < 2) ? 0 : 11 - rem;
                if (nums[12] != dv1) return false;

                sum = 0;

                rem = sum % 11;
                int dv2 = (rem < 2) ? 0 : 11 - rem;
                return nums[13] == dv2;
            }
                return false;
            }
        }
    }
}
