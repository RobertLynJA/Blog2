import React, { FunctionComponent } from "react";

import { Story } from "store/StoriesStore";
import StoryContent from "./StoryContent";

interface Props {
  story: Story;
  className?: string;
}

const StoryFull: FunctionComponent<Props> = (props) => {
  const className = props.className || "";

  return (
    <div className={`bg-secondary p-5 my-2.5 rounded-lg ${className}`}>
      <div className="text-xl font-medium">{props.story.title}</div>
      <StoryContent className="pt-4 pb-2"
        content={props.story.content}
        encoding={props.story.encoding}
      />
      <div className="text-sm font-light">
        {new Date(props.story.publishedDate).toUTCString()}
      </div>
    </div>
  );
};

export default React.memo(StoryFull);
