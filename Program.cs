using Azure;
using System;
using Azure.AI.TextAnalytics;
using System.Collections.Generic;

namespace Example
{
    class Program
    {
        // Requires env vars: LANGUAGE_KEY and LANGUAGE_ENDPOINT
        static string languageKey = Environment.GetEnvironmentVariable("LANGUAGE_KEY");
        static string languageEndpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT");

        private static readonly AzureKeyCredential credentials = new AzureKeyCredential(languageKey);
        private static readonly Uri endpoint = new Uri(languageEndpoint);

        static void SentimentAnalysisWithOpinionMiningExample(TextAnalyticsClient client)
        {
            var documents = new List<string>
            {
                "The food and service were unacceptable. The concierge was nice, however."
            };

            AnalyzeSentimentResultCollection reviews = client.AnalyzeSentimentBatch(
                documents,
                options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true }
            );

            foreach (AnalyzeSentimentResult review in reviews)
            {
                Console.WriteLine($"Document sentiment: {review.DocumentSentiment.Sentiment}\n");
                Console.WriteLine($"\tPositive: {review.DocumentSentiment.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative: {review.DocumentSentiment.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral: {review.DocumentSentiment.ConfidenceScores.Neutral:0.00}\n");

                foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
                {
                    Console.WriteLine($"\tSentence: \"{sentence.Text}\"");
                    Console.WriteLine($"\tSentiment: {sentence.Sentiment}");

                    foreach (SentenceOpinion op in sentence.Opinions)
                    {
                        Console.WriteLine($"\t\tTarget: {op.Target.Text} ({op.Target.Sentiment})");
                        foreach (AssessmentSentiment assess in op.Assessments)
                        {
                            Console.WriteLine($"\t\t→ {assess.Text}: {assess.Sentiment}");
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            SentimentAnalysisWithOpinionMiningExample(client);
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
