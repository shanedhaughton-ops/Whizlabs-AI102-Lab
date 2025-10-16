# Whizlabs AI-102 Lab – Sentiment Analysis with Opinion Mining

This lab demonstrates how to perform **Sentiment Analysis with Opinion Mining** using **Azure AI Language Service** in a `.NET Core` console application.  
It is aligned with the **Microsoft Azure AI Engineer (AI-102)** certification objectives.
<img width="1088" height="520" alt="create_a_virtual_machine_44_17" src="https://github.com/user-attachments/assets/77622008-0cad-40ac-aba3-611f54741368" />

## 🧠 Overview
- Create and configure an **Azure AI Language** resource.
- Set environment variables for secure authentication.
- Build a `.NET Core` console app using **Azure.AI.TextAnalytics**.
- Run sentiment analysis with opinion mining.
- Validate and clean up your Azure resources.

## 🧩 Lab Tasks

### Task 1 – Sign in to Azure Portal
1. Go to https://portal.azure.com (Incognito recommended).  
2. Sign in with your assigned credentials.  
3. If another account appears, sign out and clear cache.

### Task 2 – Create a Language Service Resource
1. **Create a resource** → search **Language Service**.  
2. Click **Continue to create your resource**.  
3. Configure:
   - Subscription: default
   - Resource group: existing
   - Region: **East US**
   - Name: unique (e.g., `ai102-lang-demo`)
   - Pricing tier: **S (1k calls/min)**
4. Check **Responsible AI Notice** → **Review + Create** → **Create**.

### Task 3 – Create Environment Variables
From your resource’s **Keys and endpoints**, copy **Key** and **Endpoint**.  
Open Windows Terminal and set:
```powershell
setx LANGUAGE_KEY your-key
setx LANGUAGE_ENDPOINT your-endpoint
```

### Task 4 – Build a .NET Core App
1. Open **Visual Studio** → **Create a new project** → **Console App (.NET Core)**.  
2. **Manage NuGet Packages** → install `Azure.AI.TextAnalytics`.  
3. Replace `Program.cs` with the code in this repo (see below).  
4. Run the app to see document/sentence sentiment and opinion targets.

### Task 5 – Validation
Use Whizlabs **Validate My Lab** to confirm completion.

### Task 6 – Delete Resources
In **Resource groups**, select lab resources → **Delete** → type `delete` to confirm.

## 🧩 Code Explanation
- Uses **environment variables** for credentials.
- **TextAnalyticsClient** calls `AnalyzeSentimentBatch` with opinion mining enabled.
- Prints overall and per-sentence sentiment with opinion targets/assessments.

## ✅ Lab Summary
- Deployed Language Service and configured secure access.
- Implemented sentiment + opinion mining in a .NET console app.
- Validated outputs and deleted resources post-lab.

## 🧾 References
- Azure Text Analytics: https://learn.microsoft.com/azure/ai-services/language-service/overview
- .NET SDK (Azure.AI.TextAnalytics): https://learn.microsoft.com/dotnet/api/overview/azure/ai.textanalytics-readme

**Author:** Shane Haughton  
**Platform:** Whizlabs AI-102 Lab Environment  
**Last Updated:** October 2025
