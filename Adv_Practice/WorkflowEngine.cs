using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public enum LoanState
    {
        Draft,
        Submitted,
        InReview,
        Approved,
        Rejected,
        Disbursed
    }

    public class LoanWorkflow
    {
        private readonly Dictionary<int, LoanState> states = new Dictionary<int, LoanState>();
        private readonly Dictionary<int, List<LoanState>> history = new Dictionary<int, List<LoanState>>();

        public void Create(int id)
        {
            states[id] = LoanState.Draft;
            history[id] = new List<LoanState> { LoanState.Draft };
        }

        public void ChangeState(int id, LoanState newState)
        {
            var current = states[id];

            if (newState == LoanState.Submitted && current != LoanState.Draft) throw new InvalidOperationException();
            if (newState == LoanState.InReview && current != LoanState.Submitted) throw new InvalidOperationException();
            if (newState == LoanState.Approved && current != LoanState.InReview) throw new InvalidOperationException();
            if (newState == LoanState.Rejected && current != LoanState.InReview) throw new InvalidOperationException();
            if (newState == LoanState.Disbursed && current != LoanState.Approved) throw new InvalidOperationException();

            states[id] = newState;
            history[id].Add(newState);
        }

        public LoanState GetState(int id) => states[id];
    }

    [TestFixture]
    public class LoanWorkflowTests
    {
        [Test]
        public void ValidWorkflowProgresses()
        {
            var wf = new LoanWorkflow();
            wf.Create(1);
            wf.ChangeState(1, LoanState.Submitted);
            wf.ChangeState(1, LoanState.InReview);
            wf.ChangeState(1, LoanState.Approved);
            wf.ChangeState(1, LoanState.Disbursed);

            Assert.That(wf.GetState(1), Is.EqualTo(LoanState.Disbursed));
        }
    }

    class WorkflowEngine
    {
        static void Main() { }
    }
}
