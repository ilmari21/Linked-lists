using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkedListTesting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//TestIndexOperations();
		//TestConstructor();
		TestAddRemove();
		TestAddBeforeAfter();
		TestEnumeration();
		TestAddStart();
	}

	//void TestIndexOperations()
	//{
	//	var dll = new DoubleLinkedList<string>();
	//	print("Test index");
	//	dll.AddLast("Foo");
	//	dll.AddLast("Bar");
	//	print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
	//	print("Expected Count: 2, Value: Bar");
	//	print(dll);
	//}

	//void TestConstructor() {
	//	print("Test Constructor");
	//	var dll = new DoubleLinkedList<string>(new string[] {"Foo", "Bar"});
	//	print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
	//	print("Expected Count: 2, Value: Bar");
	//	print(dll);
	//}

	void TestAddRemove() {
		var dll = new DoubleLinkedList<string>();
		print("Test Add");
        dll.AddLast("Foo");
        dll.AddLast("Bar");
        dll.AddLast("Baz");
		print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
		print("Expected Count: 3, Value: Bar");
		print(dll);
		print("Test Remove");
        dll.Remove("Bar");
		print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
		print("Expected Count: 2, Value: Baz");
		print(dll);
	}

	void TestAddBeforeAfter()
	{
		var dll = new DoubleLinkedList<string>();
		print("Test Add Before/After");
		dll.AddLast("Baz");
		dll.AddBefore(dll.First, "Foo");
		dll.AddBefore(dll.GetNode(1), "Bar");
		print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
		print("Expected Count: 3, Value: Bar");
		print(dll);
	}


	void TestEnumeration() {
		print("Test Enumeration");
		var dll = new DoubleLinkedList<string>(new string[] {"Foo", "Bar", "Baz"});
		foreach (var item in dll) {
			print(item);
		}
		print("Expected: Foo, Bar, Baz");
	}

	void TestAddStart() {
		var dll = new DoubleLinkedList<string>();
		print("Test Add Start");
        dll.AddStart("Bar");
        dll.AddStart("Foo");
		print("Count: " + dll.Count + ", Value at 1: " + dll.GetValue(1));
		print("Expected Count: 2, Value: Bar");
		print(dll);
	}

}