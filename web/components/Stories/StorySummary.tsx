import React, { FunctionComponent } from "react";
import Link from "next/link";

import { Story } from "store/StoriesStore";
import StoryContent from "./StoryContent";

interface Props {
  story: Story;
  className?: string;
}

const StorySummary: FunctionComponent<Props> = (props) => {
  return (
    <div className={props.className}>
      <div>
        <Link
          href={`/stories/${encodeURIComponent(props.story.id)}`}
          className="text-xl font-medium"
        >
          {props.story.title}
        </Link>
      </div>
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

export default React.memo(StorySummary);
