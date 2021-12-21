import { UnityEngine } from "csharp";
import Wrapper from "./utils/Wrapper";

const { Vector3, Time, Input, KeyCode } = UnityEngine;

interface Props {
  speed: number;
}

export = (...args: unknown[]) =>
  new (class extends Wrapper<Props>() {
    constructor(...args: unknown[]) {
      super(args, {
        defaultProps: { speed: 2 },
      });
      console.log("USE THESE KEYS TO MOVE: WASD, Space, Left-Ctrl");
    }
    _update(): void {
      const moveSpeed = Time.deltaTime * this.props.speed;
      const rotSpeed = moveSpeed * 50;
      this.$.transform.Translate(
        Vector3.op_Multiply(
          Vector3.forward,
          moveSpeed * Input.GetAxis("Vertical")
        )
      );
      this.$.transform.Rotate(
        Vector3.op_Multiply(Vector3.up, rotSpeed * Input.GetAxis("Horizontal"))
      );
      this.$.transform.Translate(
        Vector3.op_Multiply(
          Vector3.up,
          moveSpeed *
            (Input.GetKey(KeyCode.Space)
              ? 1
              : Input.GetKey(KeyCode.LeftControl)
              ? -1
              : 0)
        )
      );
    }
  })(...args);
