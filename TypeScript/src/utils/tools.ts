import { System } from "csharp";

/** System.Array 型を JS で扱いやすい配列にする */
export const arrayToArray = <T>(array: System.Array): T[] =>
  [...new Array(array.GetLength(0)).keys()].map((i) => array.GetValue(i));

/** List 型を JS で扱いやすい配列にする */
export const listToArray = <T>(list: System.Collections.Generic.List$1<T>) =>
  [...new Array(list.Count).keys()].map((i) => list.get_Item(i));
