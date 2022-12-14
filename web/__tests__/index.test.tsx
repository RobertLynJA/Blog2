import { render, screen } from '@testing-library/react'
import Home from '@/pages/index'

describe('Home', () => {
  it('renders a heading', () => {
    render(<Home test={[]} error={'hi'} />)

    const heading = screen.getByRole('heading', {
      name: /hello from next\.js and tailwind/i,
    })

    expect(heading).toBeInTheDocument()
  })
})
