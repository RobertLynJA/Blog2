import React, { FunctionComponent } from "react";
import ReactMarkdown from "react-markdown";

import classes from "./StoryContent.module.css";

interface Props {
  content: string;
  encoding: string;
}

const StoryContent: FunctionComponent<Props> = (props) => {
  let content: JSX.Element;

  switch (props.encoding) {
    case "markdown":
      content = (
        <div className={classes.markdownContent}>
          <ReactMarkdown children={props.content} />
        </div>
      );
      break;
    case "text":
      content = <div>{props.content}</div>;
      break;
    default:
      content = <>Unknown format</>;
      break;
  }

  return content;
};

export default React.memo(StoryContent);
