import { FunctionComponent } from 'react';

import { Story } from 'store/StoriesStore';

interface Props {
  story: Story;
}

const StoryFull : FunctionComponent<Props> = props => {
  return (
    <div>
      {props.story.content} - {new Date(props.story.publishedDate).toUTCString()}
    </div>
  );
};

export default StoryFull;