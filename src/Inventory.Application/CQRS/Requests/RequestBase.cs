using System;
using MediatR;

namespace Inventory.Application.CQRS.Requests;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IRequest"/> and adding request identity.
/// </summary>
public abstract record RequestBase : IRequest, IIdentifiableRequest
{
    protected RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    protected RequestBase(Guid id)
    {
        RequestId = id;
    }

    /// <inheritdoc/>
    public Guid RequestId { get; private set; }
}

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IRequest{TResult}"/> and adding request identity.
/// <para/><typeparamref name="TResult"/> is the type of an object, that will be returned as the command execution result.
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public abstract record RequestBase<TResult> : IRequest<TResult>, IIdentifiableRequest<TResult>
{
    protected RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    protected RequestBase(Guid id)
    {
        RequestId = id;
    }

    /// <inheritdoc/>
    public Guid RequestId { get; private set; }
}