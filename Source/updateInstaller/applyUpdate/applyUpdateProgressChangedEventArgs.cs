﻿/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateProgressChangedEventArgs : EventArgs {
		private readonly string m_description = string.Empty;
		private readonly string m_name = string.Empty;
		private readonly int m_percentDone;

		public applyUpdateProgressChangedEventArgs(string aName, string aDescription, int progressPercentage) {
			m_name = aName;
			m_description = aDescription;
			m_percentDone = progressPercentage;
		}

		/// <summary>
		/// Gibt den Namen der Aktion zurück.
		/// </summary>
		public string actionName {
			get { return m_name; }
		}

		/// <summary>
		/// Gibt die genauere Beschreibung der Aktion zurück.
		/// </summary>
		public string actionDescription {
			get { return m_description; }
		}

		/// <summary>
		/// Gibt den Fortschritt der Aktion in Prozent zurück.
		/// </summary>
		public int percentDone {
			get { return m_percentDone; }
		}
	}
}