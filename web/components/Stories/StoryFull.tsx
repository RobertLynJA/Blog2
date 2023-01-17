import React, { FunctionComponent } from "react";

import { Story } from "store/StoriesStore";
import StoryContent from "./StoryContent";

interface Props {
  story: Story;
}

const StoryFull: FunctionComponent<Props> = (props) => {
  return (
    <div>
      <div className="text-xl">{props.story.title}</div>
      <StoryContent
        content={props.story.content}
        encoding={props.story.encoding}
      />
      <div className="text-sm">
        {new Date(props.story.publishedDate).toUTCString()}
      </div>
    </div>
  );
};

export default React.memo(StoryFull);
