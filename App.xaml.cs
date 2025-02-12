﻿using TaskFlow.Views;

namespace TaskFlow;

public partial class App : Application
{
	private readonly IServiceProvider _serviceProvider;
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		_serviceProvider = serviceProvider;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var HomePage = _serviceProvider.GetRequiredService<TaskPage>();
		return new Window(HomePage);
	}
}