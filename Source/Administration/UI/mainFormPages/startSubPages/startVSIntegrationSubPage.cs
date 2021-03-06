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
using System.Drawing;
using System.Text;
using updateSystemDotNet.Administration.Core;
using System;
using System.Windows.Forms;
namespace updateSystemDotNet.Administration.UI.mainFormPages.startSubPages {
	internal sealed partial class startVSIntegrationSubPage : baseSubPage {
		public startVSIntegrationSubPage() {
			InitializeComponent();
			pageSymbol = resourceHelper.getImage("vs_ide.png");
			Id = "66dfbd81-6d84-4b5a-bbd4-750cb218bae2";

			imgImportSettings.Image = graphicUtils.shrinkImage(resourceHelper.getImage("copyProjectSettings.png"),
															   new Size(350, 70));
			MinimumSize = Size;
		}

		public override void initializeData() {
			txtCSharp.Text = generateCSharpCode();
			txtCSharp.Font = new Font("Courier New", 8);
			txtCSharp.KeyDown += txtCode_KeyDown;

			txtVB.Text = generateVBCode();
			txtVB.Font = new Font("Courier New", 8);
			txtVB.KeyDown += txtCode_KeyDown;
		}

		void txtCode_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyValue == 65)
				((TextBox)sender).SelectAll();
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e) {

			pnlCSharp.Hide();
			pnlVB.Hide();
			pnlWinForms.Hide();

			if(rbDesigner.Checked)
				pnlWinForms.Show();
			if(rbCSharp.Checked)
				pnlCSharp.Show();
			if(rbVB.Checked)
				pnlVB.Show();
		}

		private string generateCSharpCode() {
			var sbCode = new StringBuilder();

			sbCode.AppendLine("//updateController Objekt initialisieren");
			sbCode.AppendLine("updateSystemDotNet.updateController updController = new updateSystemDotNet.updateController();");
			sbCode.AppendLine(string.Format("updController.updateLocation = \"<Hier die Adresse zu den Updates eintragen>\";"));
			sbCode.AppendLine(string.Format("updController.projectId = \"{0}\";",
											Session.currentProject.projectId));
			sbCode.AppendLine(string.Format("updController.publicKey = \"{0}\";", Session.currentProject.keyPair.publicKey));
			sbCode.AppendLine();

			sbCode.AppendLine("//Releasefilter setzen, per Default wird nur nach finalen Versionen gesucht:");
			sbCode.AppendLine("updController.releaseFilter.checkForFinal = true;");
			sbCode.AppendLine(
				"updController.releaseFilter.checkForBeta = false; //Betaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			sbCode.AppendLine(
				"updController.releaseFilter.checkForAlpha = false; //Alphaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			sbCode.AppendLine();

			sbCode.AppendLine("//Anwendung nach dem Update neustarten?");
			sbCode.AppendLine("updController.restartApplication = true;");
			sbCode.AppendLine();

			sbCode.AppendLine("//Wie soll die lokale Version ermittelt werden?");
			sbCode.AppendLine(
				"updController.retrieveHostVersion = true; //Empfohlen, damit wird automatisch die Assemblyversion ermittelt.");
			sbCode.AppendLine("//Die Version kann allerdings auch manuell gesetzt werden:");
			sbCode.AppendLine("//z.B.: updController.releaseInfo.Version = \"1.2.3.4\";");
			sbCode.AppendLine();

			sbCode.AppendLine("//Einfacher Aufruf der Updatesuche:");
			sbCode.AppendLine("//updController.updateInteractive();");

			return sbCode.ToString();
		}

		private string generateVBCode() {
			var sbCode = new StringBuilder();

			sbCode.AppendLine("'updateController Objekt initialisieren");
			sbCode.AppendLine("Dim updController As New updateSystemDotNet.updateController()");
			sbCode.AppendLine(string.Format("updController.updateLocation = \"<Hier die Adresse zu den Updates eintragen>\""));
			sbCode.AppendLine(string.Format("updController.projectId = \"{0}\"",
											Session.currentProject.projectId));
			sbCode.AppendLine(string.Format("updController.publicKey = \"{0}\"", Session.currentProject.keyPair.publicKey));
			sbCode.AppendLine();

			sbCode.AppendLine("'Releasefilter setzen, per Default wird nur nach finalen Versionen gesucht:");
			sbCode.AppendLine("updController.releaseFilter.checkForFinal = True");
			sbCode.AppendLine(
				"updController.releaseFilter.checkForBeta = False 'Betaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			sbCode.AppendLine(
				"updController.releaseFilter.checkForAlpha = False 'Alphaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			sbCode.AppendLine();

			sbCode.AppendLine("'Anwendung nach dem Update neustarten?");
			sbCode.AppendLine("updController.restartApplication = True");
			sbCode.AppendLine();

			sbCode.AppendLine("'Wie soll die lokale Version ermittelt werden?");
			sbCode.AppendLine(
				"updController.retrieveHostVersion = True 'Empfohlen, damit wird automatisch die Assemblyversion ermittelt.");
			sbCode.AppendLine("'Die Version kann allerdings auch manuell gesetzt werden:");
			sbCode.AppendLine("'z.B.: updController.releaseInfo.Version = \"1.2.3.4\"");
			sbCode.AppendLine();

			sbCode.AppendLine("'Einfacher Aufruf der Updatesuche:");
			sbCode.AppendLine("'updController.updateInteractive()");

			return sbCode.ToString();
		}

		private void btnCopyControllerObject_Click(object sender, System.EventArgs e) {
			Session.copyProjectDataToClipboard();
		}

	}
}
