import React, { FunctionComponent } from "react";

import { Story } from "store/StoriesStore";
import StoryContent from "./StoryContent";

interface Props {
  story: Story;
  className?: string;
}

const StoryFull: FunctionComponent<Props> = (props) => {
  return (
    <div className={props.className}>
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
