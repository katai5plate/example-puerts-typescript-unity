import Wrapper from "./utils/Wrapper";

interface Props {
  name: string;
  extCount?: number;
}

export = (...args: unknown[]) =>
  new (class extends Wrapper<Props>() {
    constructor(...args: unknown[]) {
      super(args, {
        defaultProps: {
          name: "world",
        },
      });
    }
    _start(): void {
      console.log(
        `Hello, ${this.props.name}${"!".repeat(this.props?.extCount || 1)}`
      );
    }
  })(...args);
