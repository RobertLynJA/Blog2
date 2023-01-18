import { render, screen } from '@testing-library/react'
import Layout from '@/components/UI/Layout'

describe('Home', () => {
  it('renders a heading', () => {
    render(<Layout><></></Layout>)

    const heading = screen.getByRole('heading', {
      name: /Welcome to RobertLynJA\.com/i,
    })

    expect(heading).toBeInTheDocument()
  })
})
