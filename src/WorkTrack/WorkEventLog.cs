﻿using System;
using System.Collections.Generic;

namespace WorkTrack
{
	public class WorkEventLog
	{
		public decimal HistoryClearPeriodInDays { get; private set; }

		public DateTime PeriodDate { get; private set; }

		public HashSet<WorkEventArgs> EventsHistory { get; private set; }

		public WorkEventLog(decimal historyClearPeriodInDays, HashSet<WorkEventArgs> eventsHistory, WorkTracker workTracker)
		{
			this.PeriodDate = DateTime.Now;
			this.HistoryClearPeriodInDays = historyClearPeriodInDays;
			this.EventsHistory = eventsHistory ?? new HashSet<WorkEventArgs>();

			workTracker.TrackedWork += (_, actionArgs) => this.HandleTrackedWork(actionArgs);
		}

		protected void HandleTrackedWork(WorkEventArgs eventArgs)
		{
			TimeSpan diffResult = eventArgs.Date.Subtract(this.PeriodDate);
			if ((decimal)diffResult.TotalDays >= this.HistoryClearPeriodInDays)
			{
				this.PeriodDate = eventArgs.Date;
				this.EventsHistory = new HashSet<WorkEventArgs>();
			}

			this.EventsHistory.Add(eventArgs);
		}
	}
}