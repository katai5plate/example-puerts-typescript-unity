import { UnityEngine } from "csharp";
import Wrapper from "../utils/Wrapper";

const { Vector3, Time } = UnityEngine;

export = (...args: unknown[]) =>
  new (class extends Wrapper() {
    constructor(...args: unknown[]) {
      super(args);
    }
    _start(): void {
      console.log("Hello, World!");
    }
    _update(): void {
      const SPEED = 100;
      const t = Time.deltaTime;
      this.$.transform.Rotate(
        Vector3.op_Multiply(new Vector3(-t, t * 0.25, -t * 0.5), SPEED)
      );
    }
  })(...args);
