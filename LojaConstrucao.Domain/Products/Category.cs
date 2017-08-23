﻿using System;

namespace LojaConstrucao.Domain
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string aName)
        {
            ValidateAndSetName(aName);
        }

        public void Update(string aName)
        {
            ValidateAndSetName(aName);
        }
        private void ValidateAndSetName(string aName)
        {
            DomainException.When(string.IsNullOrEmpty(aName), "Nome é requerido");

            Name = aName;
        }
    }
}
