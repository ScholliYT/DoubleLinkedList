using System;
using NUnit.Framework;

namespace DoubleLinkedList {
    [TestFixture]
    public class DoubleLinkedListTest {
        private readonly string[] testElementStrings = {"A", "B", "C", "D", "E", "F"};
        private DoubleLinkedList list;

        [SetUp]
        public void init() {
            list = new DoubleLinkedList();
        }

        private void fillForTest() {
            foreach (string s in testElementStrings) {
                list.append(s);
            }
        }

        [Test]
        public void isEmpty() {
            Assert.AreEqual(true, list.isEmpty());
            fillForTest();
            Assert.AreEqual(false, list.isEmpty());
            list.clear();
            Assert.AreEqual(true, list.isEmpty());
        }

        [Test]
        public void hasAccess() {
            fillForTest();
            Assert.AreEqual(false, list.hasAccess());
            list.toFirst();
            Assert.AreEqual(true, list.hasAccess());
            list.clear();
            Assert.AreEqual(false, list.hasAccess());
        }

        [Test, Category("position")]
        public void toFirst() {
            fillForTest();
            list.toFirst();
            Assert.AreSame(testElementStrings[0], list.getObject());
        }

        [Test, Category("position")]
        public void toLast() {
            fillForTest();
            list.toLast();
            Assert.AreSame(testElementStrings[testElementStrings.Length - 1], list.getObject());
        }

        [Test]
        public void append() {
            fillForTest();
            const string s = "append";
            list.append(s);
            list.toLast();
            Assert.AreSame(s, list.getObject());
        }

        [Test]
        public void remove() {
            fillForTest();
            removeFirst();

            list.clear();
            fillForTest();
            removeMiddle();

            list.clear();
            fillForTest();
            removeLast();

            list.clear();
            fillForTest();
            removeMultiple();
        }

        private void removeMultiple() {
            list.toFirst();
            list.next(); // B
            list.remove(); // remove B
            Assert.AreSame(testElementStrings[2], list.getObject());
            list.remove(); // remove C
            Assert.AreSame(testElementStrings[3], list.getObject());
            list.next();
            list.toFirst();
            Assert.AreSame(testElementStrings[0], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[3], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[4], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[5], list.getObject());
            list.next();
            Assert.AreEqual(false, list.isEmpty());
            Assert.AreEqual(false, list.hasAccess());
        }

        private void removeLast() {
            list.toLast();
            list.remove();
            Assert.AreEqual(false, list.isEmpty());
            Assert.AreEqual(false, list.hasAccess());
            list.toFirst();
            Assert.AreSame(testElementStrings[0], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[1], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[2], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[3], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[4], list.getObject());
            list.next();
            Assert.AreEqual(false, list.isEmpty());
            Assert.AreEqual(false, list.hasAccess());
        }

        private void removeMiddle() {
            list.toFirst();
            list.next(); // B
            list.next(); // C
            list.remove(); // remove C
            Assert.AreSame(testElementStrings[3], list.getObject());
            list.toFirst();
            Assert.AreSame(testElementStrings[0], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[1], list.getObject());
            list.next();
            Assert.AreSame(testElementStrings[3], list.getObject());
        }


        private void removeFirst() {
            list.toFirst();
            list.remove();
            Assert.AreSame(testElementStrings[1], list.getObject());
            list.toFirst();
            Assert.AreSame(testElementStrings[1], list.getObject());
        }
    }
}