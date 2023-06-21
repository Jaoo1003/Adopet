﻿using Adopet___Alura_Challenge_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Tests.Helper {
    static class TestDataHelper {

        public static List<Abrigo> GetFakeAbrigoList() {
            return new List<Abrigo> {
                new Abrigo {
                    Id = 1,
                    Logradouro = "rua teste1",
                    Numero = 123,
                    Estado = "estado teste1",
                    Pets = {}
                },
                new Abrigo {
                    Id = 2,
                    Logradouro = "rua teste2",
                    Numero = 321,
                    Estado = "estado teste2",
                    Pets = {}
                }
            };
        }
    }
}