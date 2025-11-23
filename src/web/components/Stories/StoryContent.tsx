import React, { FunctionComponent } from "react";
import ReactMarkdown from "react-markdown";

import classes from "./StoryContent.module.css";

interface Props {
  content: string;
  encoding: string;
  className?: string;
}

const StoryContent: FunctionComponent<Props> = (props) => {
  let content: JSX.Element;
  const className = props.className || "";

  switch (props.encoding) {
    case "markdown":
      content = (
        <div className={`${classes.markdownContent} ${className}`}>
          <ReactMarkdown children={props.content} />
        </div>
      );
      break;
    case "text":
      content = <div className={className}>{props.content}</div>;
      break;
    default:
      content = <div className={className}>Unknown format</div>;
      break;
  }

  return content;
};

export default React.memo(StoryContent);
