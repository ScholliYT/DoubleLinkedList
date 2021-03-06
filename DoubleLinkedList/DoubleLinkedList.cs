﻿namespace DoubleLinkedList {
    public class DoubleLinkedList {
        private Node start { get; set; }
        private Node current { get; set; }
        private Node end { get; set; }

        public bool isEmpty() {
            return start == null;
        }

        public bool hasAccess() {
            return current != null;
        }

        public void next() {
            if (!hasAccess()) return;
            current = current.next;
            // current = current == end ? null : current.next;
        }

        public void toFirst() {
            current = start;
        }

        public void toLast() {
            current = end;
        }

        public object getObject() {
            return hasAccess() ? current.obj : null;
        }

        public void setObject(object pObject) {
            if (hasAccess() && pObject != null) {
                current.obj = pObject;
            }
        }

        public void append(object _pObject) {
            if (_pObject == null) return;
            Node nextNode = new Node {
                prev = end,
                next = null,
                obj = _pObject
            };
            if (isEmpty()) {
                start = nextNode;
            }
            else {
                end.next = nextNode;
            }

            end = nextNode;
        }

        public void insert(object pObject) {
            if (pObject == null) return;
            if (isEmpty()) {
                append(pObject);
            }
            else if (hasAccess()) {
                Node prevNode = new Node {
                    prev = current.prev,
                    next = current,
                    obj = pObject
                };
                current.prev = prevNode;
            }
        }

        /// <summary>
        /// This method concats (appends) pList to this List. 
        /// </summary>
        /// <param name="pList">The List to concat</param>
        public void concat(DoubleLinkedList pList) {
            if (pList == null || pList.isEmpty()) return;

            if (isEmpty()) {
                start = pList.start; // This list is empty
            }
            else {
                end.next = pList.start;
                pList.start.prev = end;
            }

            end = pList.end;
            pList.clear();
        }

        public void remove() {
            if (!hasAccess()) return;
            if (current != start) {
                current.prev.next = current.next;
            }
            else {
                start = current.next;
            }

            if (current != end) {
                current.next.prev = current.prev;
            }

            current = current.next;
        }


        public void clear() {
            start = null;
            end = null;
            current = null;
        }

        /// <summary>
        /// This method appends a Node at the end of this list. If this list is empty the Node to append will become the first Node
        /// </summary>
        /// <param name="_node">The Node to append to the current list</param>
        private void append(Node _node) {
            if (isEmpty()) {
                start = _node;
            }

            end = _node;
        }
    }
}