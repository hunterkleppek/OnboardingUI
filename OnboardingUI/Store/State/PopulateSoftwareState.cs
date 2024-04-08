﻿using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.State;

public class PopulateSoftwareState : RootState
{
    public PopulateSoftwareState(bool isLoading, string currentErrorMessage)
        : base(isLoading, currentErrorMessage) { }

    public List<SoftwareClass>? Software { get; set; }
    public int Role { get; set; }
    public int Department { get; set; }
}